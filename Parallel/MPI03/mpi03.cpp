#include <iostream>
#include <mpi.h>
using namespace std;

int main(int argc, char** argv)
{
	int rank, size, x;
	MPI_Status status;
	MPI_Init(&argc, &argv);
	MPI_Comm_rank(MPI_COMM_WORLD, &rank);
	MPI_Comm_size(MPI_COMM_WORLD, &size);
	if (rank % 2 == 0)
	{
		MPI_Send(&rank, 1, MPI_INT, (rank + 1) % size, 1, MPI_COMM_WORLD);
		MPI_Recv(&x, 1, MPI_INT, (rank + size - 1) % size, 1, MPI_COMM_WORLD, &status);
	}
	else
	{
		MPI_Recv(&x, 1, MPI_INT, (rank + size - 1) % size, 1, MPI_COMM_WORLD, &status);
		MPI_Send(&rank, 1, MPI_INT, (rank + 1) % size, 1, MPI_COMM_WORLD);
	}
	printf("%d get %d\n", rank, x);
	MPI_Finalize();
	return 0;
}
