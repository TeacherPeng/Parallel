/* -*- Mode: C; c-basic-offset:4 ; -*- */
/*
 *  (C) 2001 by Argonne National Laboratory.
 *      See COPYRIGHT in top-level directory.
 */

 /* This is an interactive version of cpi */
#include <mpi.h>
#include <iostream>
using namespace std;

double f(double a)
{
    return (4.0 / (1.0 + a * a));
}

int main(int argc, char* argv[])
{
    int done = 0, n = 0, myid, numprocs, i;
    double PI25DT = 3.141592653589793238462643;
    double mypi, pi, h, sum, x;
    double startwtime = 0.0, endwtime;
    int  namelen;
    char processor_name[MPI_MAX_PROCESSOR_NAME];

    MPI_Init(&argc, &argv);
    MPI_Comm_size(MPI_COMM_WORLD, &numprocs);
    MPI_Comm_rank(MPI_COMM_WORLD, &myid);
    MPI_Get_processor_name(processor_name, &namelen);

    while (!done) {
        if (myid == 0) {
            cout << "Enter the number of intervals: (0 quits) ";
            if (cin >> n) {
                cout << "No number entered; quitting." << endl;
                n = 0;
            }
            startwtime = MPI_Wtime();
        }
        MPI_Bcast(&n, 1, MPI_INT, 0, MPI_COMM_WORLD);
        if (n == 0)
            done = 1;
        else {
            h = 1.0 / (double)n;
            sum = 0.0;
            for (i = myid + 1; i <= n; i += numprocs) {
                x = h * ((double)i - 0.5);
                sum += f(x);
            }
            mypi = h * sum;
            MPI_Reduce(&mypi, &pi, 1, MPI_DOUBLE, MPI_SUM, 0, MPI_COMM_WORLD);

            if (myid == 0) {
                cout << "pi is approximately " << pi << ", Error is " << fabs(pi - PI25DT) << endl;
                endwtime = MPI_Wtime();
                cout << "wall clock time = " << endwtime - startwtime << endl;
            }
        }
    }
    MPI_Finalize();
    return 0;
}
