#include <mpi.h>
#include <iostream>
using namespace std;

int main(int argc, char* argv[])
{
    int rank;
    MPI_Init(&argc, &argv);
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);

    char msg1[7] = "1", msg3[17] = "3";
    double msg2[2]{ 0,0 };
    int s1, s2, s3;
    MPI_Status status;
    MPI_Pack_size(7, MPI_CHAR, MPI_COMM_WORLD, &s1);
    MPI_Pack_size(2, MPI_DOUBLE, MPI_COMM_WORLD, &s2);
    MPI_Pack_size(17, MPI_CHAR, MPI_COMM_WORLD, &s3);

    int bufsize = 3 * MPI_BSEND_OVERHEAD + s1 + s2 + s3;
    char* buf = new char[bufsize];
    *buf = '\0';

    MPI_Buffer_attach(buf, bufsize);
    if (rank == 0)
    {
        MPI_Bsend(msg1, 7, MPI_CHAR, 1, 0, MPI_COMM_WORLD);
        MPI_Bsend(msg2, 2, MPI_DOUBLE, 1, 0, MPI_COMM_WORLD);
        MPI_Bsend(msg3, 17, MPI_CHAR, 1, 0, MPI_COMM_WORLD);
    }
    else
    {
        MPI_Recv(msg1, 7, MPI_CHAR, 0, 0, MPI_COMM_WORLD, &status);
        MPI_Recv(msg2, 2, MPI_DOUBLE, 0, 0, MPI_COMM_WORLD, &status);
        MPI_Recv(msg3, 17, MPI_CHAR, 0, 0, MPI_COMM_WORLD, &status);
    }
    MPI_Buffer_detach(&buf, &bufsize);

    delete[]buf;
    MPI_Finalize();
    return 0;
}
