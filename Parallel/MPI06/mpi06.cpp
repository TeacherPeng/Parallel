#include <mpi.h>
#include <iostream>
using namespace std;

int  GlobalReadInteger();
void Hello();
void Ring();

int main(int argc, char* argv[])
{

	int me, option, namelen, size;
	char processor_name[MPI_MAX_PROCESSOR_NAME];

	MPI_Init(&argc, &argv);
	MPI_Comm_rank(MPI_COMM_WORLD, &me);
	MPI_Comm_size(MPI_COMM_WORLD, &size);

	if (size < 2)
	{
		cout << "systest requires at least 2 processes" << endl;
		MPI_Abort(MPI_COMM_WORLD, 1);
	}

	MPI_Get_processor_name(processor_name, &namelen);

	cout << "Process " << me << " is alive on " << processor_name << endl;

	while (1)
	{
		MPI_Barrier(MPI_COMM_WORLD);

	again:
		if (me == 0)
		{
			cout << "Options: 0 = quit, 1 = Hello, 2 = Ring :  ";
		}
		option = GlobalReadInteger();
		if ((option < 0) || (option > 4))
			goto again;

		switch (option)
		{
		case 0:
			MPI_Finalize();
			return (0);
		case 1:
			Hello();     break;
		case 2:
			Ring();      break;
		default:
			cout << "systest: invalid option " << option << endl;
			break;
		}
	}
}

int GlobalReadInteger()
/*
Process zero reads an integer from stdin and broadcasts
to everyone else
*/
{
	int me, value = 0, type = 999, zero = 0;

	MPI_Comm_rank(MPI_COMM_WORLD, &me);
	if (me == 0)
	{
		// Ctrl+Z means end of input (EOF)
		if (cin >> value)
		{
			cout << "failed reading integer value from stdin" << endl;
		}
	}
	MPI_Bcast(&value, 1, MPI_INT, 0, MPI_COMM_WORLD);
	return value;
}

void Hello()
/*
Everyone exchanges a hello message with everyone else.
The hello message just comprises the sending and target nodes.
*/
{
	int nproc, me;
	int type = 1;
	int buffer[2], node;
	MPI_Status status;

	MPI_Comm_rank(MPI_COMM_WORLD, &me);
	MPI_Comm_size(MPI_COMM_WORLD, &nproc);

	if (me == 0)
	{
		cout << endl << "Hello test ... show network integrity" << endl << "----------" << endl << endl;
	}

	for (node = 0; node < nproc; node++)
	{
		if (node != me)
		{
			buffer[0] = me;
			buffer[1] = node;
			MPI_Send(buffer, 2, MPI_INT, node, type, MPI_COMM_WORLD);
			MPI_Recv(buffer, 2, MPI_INT, node, type, MPI_COMM_WORLD, &status);

			if ((buffer[0] != node) || (buffer[1] != me))
			{
				cout << "Hello: " << buffer[0] << "!=" << node << " or " << buffer[1] << "!=" << me << endl;
				cout << "Mismatch on hello process ids; node = " << node << endl;
			}

			cout << "Hello from " << me << " to " << node << endl;
		}
	}
}

void Ring()       /* Time passing a message round a ring */
{
	int nproc, me;
	MPI_Status status;
	int type = 4;
	int left, right;
	char* buffer;
	int lenbuf, max_len;
	double us_rate;
	double start_ustime, used_ustime;

	MPI_Comm_rank(MPI_COMM_WORLD, &me);
	MPI_Comm_size(MPI_COMM_WORLD, &nproc);
	left = (me + nproc - 1) % nproc;
	right = (me + 1) % nproc;

	/* Find out how big a message to use */

	if (me == 0)
	{
		cout << "\nRing test...time network performance\n---------\n\n" << endl;
		cout << "Input maximum message size: " << endl;
	}
	max_len = GlobalReadInteger();
	if ((max_len <= 0) || (max_len >= 4 * 1024 * 1024))
		max_len = 512 * 1024;
	buffer = new char[max_len];
	if (buffer == nullptr)
	{
		cout << "Process " << me << " could not allocate buffer of size " << max_len << endl;
		MPI_Abort(MPI_COMM_WORLD, 7777);
	}
	*buffer = '\0';

	lenbuf = 1;
	while (lenbuf <= max_len)
	{
		start_ustime = MPI_Wtime();
		if (me == 0)
		{
			MPI_Send(buffer, lenbuf, MPI_CHAR, left, type, MPI_COMM_WORLD);
			MPI_Recv(buffer, lenbuf, MPI_CHAR, right, type, MPI_COMM_WORLD, &status);
		}
		else
		{
			MPI_Recv(buffer, lenbuf, MPI_CHAR, right, type, MPI_COMM_WORLD, &status);
			MPI_Send(buffer, lenbuf, MPI_CHAR, left, type, MPI_COMM_WORLD);
		}
		used_ustime = MPI_Wtime() - start_ustime;

		if (used_ustime > 0)	/* rate is megabytes per second */
			us_rate = ((double)nproc * lenbuf) / (used_ustime * (double)1000000);
		else
			us_rate = 0.0;
		if (me == 0)
		{
			cout << "len=" << lenbuf << " bytes, used= " << used_ustime << " sec., rate= " << us_rate << " Mbytes/sec" << endl;
		}
		lenbuf *= 2;
	}
	if (me == 0)
	{
		cout << "Clock resolution in seconds: " << MPI_Wtick() << endl;
	}
	delete[] buffer;
}
