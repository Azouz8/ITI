class Teacher {
    constructor(name) { this.name = name; }
    describe() { return `Teacher: ${this.name}`; }
}

class TeacherDecorator {
    constructor(teacher) { this.teacher = teacher; }
    describe() { return this.teacher.describe(); }
}

class WithSalary extends TeacherDecorator {
    constructor(teacher, salary) {
        super(teacher);
        this.salary = salary;
    }
    describe() {
        return `${super.describe()}, salary: $${this.salary}`;
    }
}

class WithNationality extends TeacherDecorator {
    constructor(teacher, nationality) {
        super(teacher);
        this.nationality = nationality;
    }
    describe() {
        return `${super.describe()}, nationality: ${this.nationality}`;
    }
}

class WithStreet extends TeacherDecorator {
    constructor(teacher, street) {
        super(teacher);
        this.street = street;
    }
    describe() {
        return `${super.describe()}, street: ${this.street}`;
    }
}

let teacher = new Teacher("Ahmed");
teacher = new WithSalary(teacher, 5000);
teacher = new WithNationality(teacher, "Egyptian");
teacher = new WithStreet(teacher, "Tahrir St.");

console.log(teacher.describe());