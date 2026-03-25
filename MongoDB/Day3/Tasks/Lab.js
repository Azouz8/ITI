// Create student collection that has (FirstName, lastName,
// IsFired, FacultyID, array of objects, each object has
// CourseID, grade).
db.createCollection("student", {
  validator: {
    $jsonSchema: {
      bsonType: "object",
      required: ["firstName", "lastName", "isFired", "facultyID"],
      additionalProperties: false,
      properties: {
        _id: {},
        firstName: { bsonType: "string" },
        lastName: { bsonType: "string" },
        isFired: { bsonType: "bool" },
        facultyID: { bsonType: "objectId" },
        courses: {
          bsonType: "array",
          items: {
            bsonType: "object",
            required: ["courseID", "grade"],
            properties: {
              courseID: { bsonType: "objectId" },
              grade: { bsonType: "number", minimum: 0, maximum: 100 },
            },
          },
        },
      },
    },
  },
});

// Create Faculty collection that has (Faculty Name, Address).
db.createCollection("faculty", {
  validator: {
    $jsonSchema: {
      bsonType: "object",
      required: ["name"],
      additionalProperties: false,
      properties: {
        _id: {},
        name: { bsonType: "string" },
        address: { bsonType: "string" },
      },
    },
  },
});

// Create Course collection, which has (Course Name, Final Mark).
db.createCollection("course", {
  validator: {
    $jsonSchema: {
      bsonType: "object",
      required: ["name"],
      additionalProperties: false,
      properties: {
        _id: {},
        name: { bsonType: "string" },
        finalMark: { bsonType: "number" },
      },
    },
  },
});

db.faculty.insertMany([
  {
    name: "Faculty of Computer Science",
    address: "Building A, 12 Tech Street",
  },
  {
    name: "Faculty of Engineering",
    address: "Building B, 34 Engineering Ave",
  },
  {
    name: "Faculty of Business",
    address: "Building C, 56 Commerce Road",
  },
]);

db.course.insertMany([
  {
    name: "Introduction to Programming",
    finalMark: 100,
  },
  {
    name: "Database Systems",
    finalMark: 100,
  },
  {
    name: "Data Structures",
    finalMark: 100,
  },
  {
    name: "Calculus I",
    finalMark: 100,
  },
  {
    name: "Business Management",
    finalMark: 100,
  },
]);

const facCS = db.faculty.findOne({ name: "Faculty of Computer Science" })._id;
const facEng = db.faculty.findOne({ name: "Faculty of Engineering" })._id;
const facBus = db.faculty.findOne({ name: "Faculty of Business" })._id;

const courseIntro = db.course.findOne({
  name: "Introduction to Programming",
})._id;
const courseDB = db.course.findOne({ name: "Database Systems" })._id;
const courseDS = db.course.findOne({ name: "Data Structures" })._id;
const courseCalc = db.course.findOne({ name: "Calculus I" })._id;
const courseBusiness = db.course.findOne({ name: "Business Management" })._id;

db.student.insertMany([
  {
    firstName: "Alice",
    lastName: "Johnson",
    isFired: false,
    facultyID: facCS,
    courses: [
      { courseID: courseIntro, grade: 88 },
      { courseID: courseDB, grade: 92 },
    ],
  },
  {
    firstName: "Bob",
    lastName: "Smith",
    isFired: false,
    facultyID: facCS,
    courses: [
      { courseID: courseIntro, grade: 74 },
      { courseID: courseDS, grade: 81 },
    ],
  },
  {
    firstName: "Carol",
    lastName: "Williams",
    isFired: true,
    facultyID: facEng,
    courses: [
      { courseID: courseCalc, grade: 55 },
      { courseID: courseDS, grade: 60 },
    ],
  },
  {
    firstName: "David",
    lastName: "Brown",
    isFired: false,
    facultyID: facEng,
    courses: [
      { courseID: courseCalc, grade: 95 },
      { courseID: courseIntro, grade: 89 },
    ],
  },
  {
    firstName: "Eva",
    lastName: "Davis",
    isFired: false,
    facultyID: facBus,
    courses: [
      { courseID: courseBusiness, grade: 78 },
      { courseID: courseDB, grade: 83 },
    ],
  },
]);

// Display each student Full Name along with his average
// grade in all courses. $concat
db.student.aggregate([
  {
    $project: {
      fullName: { $concat: ["$firstName", " ", "$lastName"] },
      avgGrade: { $avg: "$courses.grade" },
    },
  },
]);

// 3. Using aggregation display the sum of final mark for all
// courses in Course collection.
db.course.aggregate([
  {
    $group: {
      _id: {},
      totalSum: {
        $sum: "$finalMark",
      },
    },
  },
]);

// 4. Implement (one to many) relation between Student and
// Course, by adding array of Courses IDs in the student object.
// • Select specific student with his name, and then display
// his courses.
db.student.aggregate([
  {
    $match: {
      firstName: "Alice",
    },
  },
  {
    $lookup: {
      from: "course",
      localField: "courses.courseID",
      foreignField: "_id",
      as: "courseDetails",
    },
  },
]);

// 5. Implement relation between Student and faculty by adding
// the faculty object in the student using _id Relation using
// $Lookup.
// • Select specific student with his name, and then display
// his faculty
db.student.aggregate([
  {
    $match: {
      firstName: "Alice",
    },
  },
  {
    $lookup: {
      from: "faculty",
      localField: "facultyID",
      foreignField: "_id",
      as: "facultyDetails",
    },
  },
]);
