#include <iostream>
using namespace std;

class BankAccount
{
private:
    string accountHolderName;
    int accountNumber;
    double balance;
    static int accountID;
    static int totalAccountsCreated;

public:
    BankAccount()
    {
        accountHolderName = "UNKNOWN";
        accountNumber = accountID;
        balance = 0;
        accountID++;
        totalAccountsCreated++;
    }
    BankAccount(string name, double balance)
    {
        accountHolderName = name;
        this->balance = balance;
        accountNumber = accountID;
        accountID++;
        totalAccountsCreated++;
    }
    BankAccount &deposit(double amount)
    {
        if (amount > 0)
        {
            balance += amount;
        }
        return *this;
    }
    void withdraw(double amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
        }
        else
        {
            cout << "Insufficient balance or invalid amount." << endl;
        }
    }
    void showAccountInfo()
    {
        cout << "Account Holder: " << accountHolderName << endl;
        cout << "Account Number: " << accountNumber << endl;
        cout << "Balance: " << balance << endl;
    }
    double getBalance()
    {
        return balance;
    }
    static int getTotalAccountsCreated()
    {
        return totalAccountsCreated;
    };
};

int BankAccount::accountID = 1;
int BankAccount::totalAccountsCreated = 0;

int main()
{
    BankAccount a1("Ali", 1000);
    BankAccount a2;

    a1.showAccountInfo();
    a1.deposit(500);
    a1.withdraw(-400);
    cout << "After transaction:" << endl;
    a1.showAccountInfo();

    cout << "--------------------------------" << endl;
    a2.showAccountInfo();
    a2.deposit(700);
    a2.withdraw(500);
    cout << "After transaction:" << endl;
    a2.showAccountInfo();

    cout << "Total Accounts Created: " << BankAccount::getTotalAccountsCreated() << endl;

    return 0;
}