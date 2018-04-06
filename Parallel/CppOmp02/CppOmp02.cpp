// CppOmp02.cpp: 基于OpenMP的多线程编程示例02
//

#include <iostream>
#include <omp.h>
using namespace std;

int main()
{
#pragma omp parallel num_threads(4)
	{
		int i = omp_get_thread_num();
		cout << "Hello from thread " << i << endl;
	}
	system("pause");
	return 0;
}