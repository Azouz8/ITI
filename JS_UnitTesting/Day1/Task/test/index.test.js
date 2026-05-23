import * as chai from "chai";
const { assert, expect } = chai;
chai.should();
import {
    capitalizeText,
    createArray,
    obj,
    obj1,
    obj2,
    obj3,
    CheckPositivity,
    Mult
} from "../index.js"


///////////////// 1
describe.skip("test capitalize function", () => {
    it("test string", () => {
        expect(capitalizeText("hamada")).to.be.a("string")
    }
    )
    it("test string", () => {
        expect(capitalizeText("hamada")).equal("HAMADA")
    }
    )
    it.skip("test int", () => {
        expect(capitalizeText(12)).to.throw("parameter should be string")
    }
    )
    it.skip("test params", () => {
        expect(() => capitalizeText()).to.throw("parameter should be string");
    })
}
)

///////////////// 2
describe.skip("test create array", () => {
    it("test type", () => {
        expect(createArray(3)).to.be.an("array")
    }
    )
    it("test input", () => {
        expect(createArray(3)).to.be.an("array").that.has.lengthOf(3).that.include(1)
    }
    )
    it("test input style 2", () => {
        assert.isArray(createArray(3));
        assert.lengthOf(createArray(3), 3);
        assert.include(createArray(3), 1)
    }
    )
    it("test input style 3", () => {
        createArray(3).should.be.an("array").that.has.lengthOf(3).that.include(1);
    })

    it("test input delayed 5s", (done) => {
        setTimeout(() => {
            expect(createArray(3)).to.be.an("array").that.has.lengthOf(3).that.include(1);
            done();
        }, 5000);
    }).timeout(6000);

    it("pending test case");
}
)

///////////////// 3
describe.skip("test types equality", () => {
    it("test equality using expect", () => {
        expect(obj1).equal(obj2)
    }
    )
    it("test equality using assert", () => {
        assert.equal(obj1, obj2)
    }
    )
    it("test equality using should", () => {
        (obj1).should.equal(obj2)
    }
    )
}
)

///////////////// 4
describe.skip("test positivity", () => {
    it("Check int using expect", () => {
        expect(CheckPositivity(4)).equal(true)
    }
    )
    it("Check int using should", () => {
        CheckPositivity(-1).should.equal(true)
    }
    )
    it("Check int using assert", () => {
        assert.equal(CheckPositivity(0), true)
    }
    )
}
)

///////////////// 5
describe("test Multiply", () => {
    it("check x > 0", () => {
        assert.isAbove(5, 0, "Input should be greater than 0")
    }
    )
    it("test return value is above zero", () => {
        assert.isAbove(Mult(5), 0, "returned value should be greater than 0");
    })
    it("test negative input", () => {
        assert.isBelow(Mult(-5), 0, "negative input returns negative result");
    })
}
)

///////////////// 6
describe("test obj3", () => {
    it("test a.b[0] includes {x: 1}", () => {
        assert.deepInclude(obj3.a.b[0], { x: 1 });
    })
})
