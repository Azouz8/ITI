class ActiveCounter {
    constructor() {
        if (ActiveCounter.instance) {
            ActiveCounter.instance.counter += 1;
            console.log("New Instance Created and the Counter value is ", ActiveCounter.instance.counter)
            return ActiveCounter.instance;
        }
        this.counter = 1;
        ActiveCounter.instance = this;
        console.log("New Instance Created and the Counter value is ", this.counter)
    }
}

class A {
    constructor() {
        this.counter = new ActiveCounter();
    }
}

class B {
    constructor() {
        this.counter = new ActiveCounter();
    }
}

class C {
    constructor() {
        this.counter = new ActiveCounter();
    }
}

const a = new A();
const a2 = new A();
const b = new B();
const b2 = new B();
const c = new C();
const c2 = new C();
