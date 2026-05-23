import app from "../app.js";

describe("Test Node Server", () => {
    const baseUrl = "http://localhost:3000";
    let server;

    beforeAll(async () => {
        await new Promise((resolve) => {
            server = app.listen(3000, () => {
                resolve();
            });
        });
    });

    afterAll(async () => {
        await new Promise((resolve) => {
            server.close(() => {
                setTimeout(() => {
                    resolve();
                }, 50);
            });
        });
    });

    it("Request 1", async () => {
        const response = await fetch(`${baseUrl}/`);
        const body = await response.text();

        expect(response.status).toEqual(200);
        expect(body).toEqual("hello world");
    });

    it("Request 2", async () => {
        const response = await fetch(`${baseUrl}/status`);
        const data = await response.json();

        expect(response.status).toEqual(200);
        expect(data.status).toEqual("ok");
    });
});