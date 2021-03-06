// CppOmp04.cpp: 基于OpenMP的多线程编程示例
//

#include <iostream>
#include <omp.h>
using namespace std;

int main()
{
	int count = 0;
	int *p = &count;
#pragma omp parallel num_threads(10)
	{
// #pragma omp atomic
		(*p)++;
	}
	cout << "Number of threads: " << count << endl;
	system("pause");
	return 0;
}
