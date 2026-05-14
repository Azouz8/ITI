class CountryService {
    getCountries() {
        console.log("fetching from API...");
        return ["Egypt", "France", "Japan", "Brazil"];
    }
}

class CountryServiceProxy {
    constructor() {
        this.realService = new CountryService();
        this.cache = null;
    }
    getCountries() {
        if (this.cache) {
            console.log("CACHED result");
            return this.cache;
        }
        this.cache = this.realService.getCountries();
        return this.cache;
    }
}

const service = new CountryServiceProxy();

console.log("Call 1:", service.getCountries());
console.log("Call 2:", service.getCountries());
console.log("Call 3:", service.getCountries());