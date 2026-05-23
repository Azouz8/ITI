import * as chai from "chai";
const { expect } = chai;
import { fetchPosts } from "../index.js";


describe("Testing Fetch Posts API", () => {
    it("return an array with the correct length and data", async () => {
        const data = await fetchPosts();
        expect(data).to.be.an("array");
        expect(data).to.have.lengthOf(30);
        expect(data[0]).to.be.an("object");
    });
});