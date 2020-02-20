#include <iostream>
#include <mpi.h>
using namespace std;
int main(int argc, char* argv[])
{
    int rank, size, processornamelen;
    char processorname[MPI_MAX_PROCESSOR_NAME];
    MPI_Status status;
    MPI_Init(&argc, &argv);
    MPI_Comm_size(MPI_COMM_WORLD, &size);
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Get_processor_name(processorname, &processornamelen);
    cout << "I'm rank " << rank << " in " << size << " processes, in processor " << processorname << endl;

    int x = -1;
    while (x != 0)
    {
        if (rank == 0)
        {
            cout << "X = ";
            cin >> x;
        }
        else
        {
            MPI_Recv(&x, 1, MPI_INT, rank - 1, 0, MPI_COMM_WORLD, &status);
            cout << "Received X = " << x << " from " << rank - 1 << " (" << processorname << ")" << endl;
        }
        if (rank < size - 1)
        {
            MPI_Send(&x, 1, MPI_INT, rank + 1, 0, MPI_COMM_WORLD);
            cout << "Send X = " << x << " to " << rank + 1 << " (" << processorname << ")" << endl;
        }
        MPI_Barrier(MPI_COMM_WORLD);
    }
    cout << "Rank " << rank << " (" << processorname << ") is over." << endl;
    MPI_Finalize();
    return 0;
}
