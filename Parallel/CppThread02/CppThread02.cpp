// CppThread02.cpp: 基于C++11的多线程编程示例02
//

#include <iostream>  
#include <thread>  
#include <mutex>
#include <chrono>  
using namespace std;

mutex mcout;

void foo(int x)
{
	mcout.lock(); cout << "foo(" << x << ") is running..." << endl; mcout.unlock();
	this_thread::sleep_for(std::chrono::seconds(2));
	mcout.lock();  cout << "foo(" << x << ") is over." << endl; mcout.unlock();
}
int main()
{
	mcout.lock();  cout << "main start..." << endl; mcout.unlock();
	thread t1(foo, 1);
	thread t2(foo, 2);
	mcout.lock(); cout << "main is running..." << endl; mcout.unlock();
	t1.join();
	t2.join();
	cout << "main is over." << endl;
	system("pause");
	return 0;
}
