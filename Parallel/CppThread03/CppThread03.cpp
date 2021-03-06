// CppThread03.cpp: 基于C++11的多线程编程示例
//

#include <iostream>
#include <thread>
#include <mutex>
using namespace std;

int cnt = 20;
mutex m;
void t1()
{
	while (cnt > 0)
	{
		// lock_guard<mutex> lockGuard(m);
		if (cnt > 0) { --cnt; cout << cnt << endl; }
	}
}
void t2()
{
	while (cnt > 0)
	{
		// lock_guard<mutex> lockGuard(m);
		if (cnt > 0) { --cnt; cout << cnt << endl; }
	}
}

int main()
{
	thread th1(t1);
	thread th2(t2);

	th1.join();
	th2.join();
	system("pause");
	return 0;
}
