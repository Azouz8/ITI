class Button {
    render() { }
}

class Checkbox {
    render() { }
}


class WindowsButton extends Button {
    render() {
        console.log("Rendering Windows Button");
    }
}

class WindowsCheckbox extends Checkbox {
    render() {
        console.log("Rendering Windows Checkbox");
    }
}


class MacButton extends Button {
    render() {
        console.log("Rendering Mac Button");
    }
}

class MacCheckbox extends Checkbox {
    render() {
        console.log("Rendering Mac Checkbox");
    }
}

class GUIFactory {
    createButton() { }
    createCheckbox() { }
}


class WindowsFactory extends GUIFactory {
    createButton() {
        return new WindowsButton();
    }

    createCheckbox() {
        return new WindowsCheckbox();
    }
}

class MacFactory extends GUIFactory {
    createButton() {
        return new MacButton();
    }

    createCheckbox() {
        return new MacCheckbox();
    }
}


class Application {
    constructor(factory) {
        this.button = factory.createButton();
        this.checkbox = factory.createCheckbox();
    }

    renderUI() {
        this.button.render();
        this.checkbox.render();
    }
}

const osType = "Windows";

let factory;

if (osType === "Windows") {
    factory = new WindowsFactory();
} else {
    factory = new MacFactory();
}

const app = new Application(factory);

app.renderUI();