const myobj = {
    name: "",
    address: '',
    age: 0
}

const handler = {
    get(target, prop) {
        if (target.hasOwnProperty(prop)) {
            return target[prop]
        }
        else {
            throw 'undefined property'
        }
    },
    set(target, prop, value) {
        if (!target.hasOwnProperty(prop)) {
            throw 'undefined property'
        }
        if (prop === 'name' && value.length == 7 && typeof value === 'string') {
            target[prop] = value
        } else if (prop === 'address' && typeof value === 'string') {
            target[prop] = value
        } else if (prop === 'age' && value >= 25 && value <= 60) {
            target[prop] = value
        } else {
            throw `invalid value for ${prop}`;
        }

    },
}

const p = new Proxy(myobj, handler)
p.name = 'pNameee'
p.age = 25;
console.log(p.age);
console.log(p.name);