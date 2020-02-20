#include <mpi.h>
#include <iostream>
using namespace std;

int main(int argc, char* argv[])
{
	int size, rank;
	char ProcessName[MPI_MAX_PROCESSOR_NAME];
	int processlen;
	MPI_Init(&argc, &argv);
	MPI_Comm_size(MPI_COMM_WORLD, &size);
	MPI_Comm_rank(MPI_COMM_WORLD, &rank);
	MPI_Get_processor_name(ProcessName, &processlen);
	cout << "Hello, World! Size is " << size << ", My rank is " << rank << ", Process name is " << ProcessName << endl;
	MPI_Finalize();
	return 0;
}
