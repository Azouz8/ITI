#include <iostream>
#include <vector>
using namespace std;

class Author
{
    string name;
    string nationality;

public:
    Author(string name, string nat) : name(name), nationality(nat) {}

    string getName() { return name; }
    string getNationality() { return nationality; }
};

class Book
{
    string title;
    int publish_year;
    // Author author; // Static
    Author *author; // Dynamic

public:
    // Static
    // Book(string title, int year, string authorName, string authorNationality)
    //     : title(title), publish_year(year), author(authorName, authorNationality) {}

    // Dynamic
    Book(string title, int year, string authorName, string authorNationality)
        : title(title), publish_year(year)
    {
        author = new Author(authorName, authorNationality);
    }

    string getTitle()
    {
        return title;
    }
    int getPubYear() { return publish_year; }

    // Static
    // string getAuthorName() { return author.getName(); }
    // string getAuthorNationality() { return author.getNationality(); }

    // Dynamic
    string getAuthorName() { return author->getName(); }
    string getAuthorNationality() { return author->getNationality(); }
    ~Book() { delete author; }
    Book(Book &book)
    {
        this->title = book.title;
        this->publish_year = book.publish_year;
        this->author = new Author(*book.author);
    }
    Book &operator=(const Book &other)
    {
        if (this != &other)
        {
            this->title = other.title;
            this->publish_year = other.publish_year;
            delete author;
            this->author = new Author(*other.author);
        }
        return *this;
    }
};

class Library
{
    vector<Book *> books;

public:
    void addBooks(Book *book)
    {
        books.push_back(book);
    }

    void listBooks()
    {
        cout << "All Books:\n";
        for (auto book : books)
        {
            cout << book->getTitle() << "\t";
            cout << "Author: " << book->getAuthorName() << "\t";
            cout << "Date: " << book->getPubYear() << endl;
        }
    }
};

class Member
{
    string name;
    int id;

public:
    Member() = default;

    Member(string name, int id) : name(name), id(id) {}

    void borrowBook(Book &b)
    {
        cout << "Member: " << name << " borrowed " << b.getTitle() << endl;
    }
};

int main()
{

    Book b1("Book 1", 2000, "Ali", "Egypt");
    Book b2("Book 2", 2001, "Azouz", "Egypt");
    Book b3("Book 3", 2002, "Mohamed", "Egypt");

    Library lib;
    lib.addBooks(&b1);
    lib.addBooks(&b2);
    lib.addBooks(&b3);

    lib.listBooks();

    Member m1("Ali", 55);
    m1.borrowBook(b1);
    Member m2("Azouz", 66);
    m2.borrowBook(b2);
}
