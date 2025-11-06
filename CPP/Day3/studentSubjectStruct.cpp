#include <iostream>
#include <array>
using namespace std;

struct course
{
    int grade;
};
struct student
{
    string name;
    array<course, 3> courses;
};

int main()
{
    int noOfStudents, noOfCourses;
    cout << "Enter the no of students: ";
    cin >> noOfStudents;
    cout << "Enter the no of courses: ";
    cin >> noOfCourses;
    array<student, 100> students;
    for (int i = 0; i < noOfStudents; i++)
    {
        cout << "Enter the name of student no. " << i + 1 << " : ";
        cin >> students[i].name;
        for (int j = 0; j < noOfCourses; j++)
        {
            cout << "Enter the grade of course no. " << j + 1 << " for student no. " << i + 1 << " : ";
            cin >> students.at(i).courses.at(j).grade;
        }
    }
    array<int, 100> courseSumForStudents = {0};
    for (int i = 0; i < noOfStudents; i++)
    {
        cout << "The courses grade sum for student no. " << i + 1 << " (" << students.at(i).name << ") : ";
        for (int j = 0; j < noOfCourses; j++)
        {
            courseSumForStudents[i] += students.at(i).courses.at(j).grade;
        }
        cout << courseSumForStudents[i] << endl;
    }
    array<int, 100> courseAverage = {0};
    for (int i = 0; i < noOfCourses; i++)
    {
        cout << "The courses average : ";
        for (int j = 0; j < noOfStudents; j++)
        {
            courseAverage.at(i) += students.at(j).courses.at(i).grade;
        }
        courseAverage.at(i) /= noOfStudents;
        cout << courseAverage.at(i) << endl;
    }
    int x;
    cin >> x;
}