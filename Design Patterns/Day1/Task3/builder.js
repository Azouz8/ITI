class Pizza {
    constructor() {
        this.size = "";
        this.cheese = false;
        this.pepperoni = false;
        this.mushrooms = false;
    }

    showPizza() {
        console.log("Pizza Details:");
        console.log("Size:", this.size);
        console.log("Cheese:", this.cheese);
        console.log("Pepperoni:", this.pepperoni);
        console.log("Mushrooms:", this.mushrooms);
    }
}

class PizzaBuilder {
    constructor() {
        this.pizza = new Pizza();
    }

    setSize(size) {
        this.pizza.size = size;
        return this;
    }

    addCheese() {
        this.pizza.cheese = true;
        return this;
    }

    addPepperoni() {
        this.pizza.pepperoni = true;
        return this;
    }

    addMushrooms() {
        this.pizza.mushrooms = true;
        return this;
    }

    build() {
        return this.pizza;
    }
}


const pizza = new PizzaBuilder().setSize("Large").addCheese().addPepperoni().build();

pizza.showPizza();