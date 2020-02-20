#include <iostream>
#include <windows.h>
using namespace std;

DWORD WINAPI MyThreadStart(LPVOID lpParameter)
{
    cout << GetCurrentThreadId() << " Running: " << reinterpret_cast<char*>(lpParameter) << endl;
    return 0;
}

int main(int argc, char* argv[])
{
    HANDLE hThread;
    DWORD dwThreadId;
    char msg[] = "Hello, World!";
    hThread = CreateThread(NULL, 0, &MyThreadStart, msg, 0, &dwThreadId);
    if (!hThread)
    {
        cerr << "Thread creation failed: " << GetLastError() << endl;
        return -1;
    }
    cout << GetCurrentThreadId() << " Created thread " << hThread << " (Id " << dwThreadId << ")" << endl;
    WaitForSingleObject(hThread, INFINITE);
    DWORD dwExitCode;
    GetExitCodeThread(hThread, &dwExitCode);
    cout << GetCurrentThreadId() << " Thread exited: " << dwExitCode << endl;
    CloseHandle(hThread);
    return 0;
}
