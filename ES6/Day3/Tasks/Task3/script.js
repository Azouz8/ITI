async function getUsers() {
    try {
        const response = await fetch("https://dummyjson.com/users");

        if (!response.ok) {
            throw new Error("Request failed");
        }

        const data = await response.json();
        const users = data.users;
        const tableBody = document.getElementById("u").getElementsByTagName('tbody')[0];

        for (const user of users) {
            const newRow = tableBody.insertRow();
            newRow.insertCell(0).textContent = user.id;
            newRow.insertCell(1).textContent = user.firstName + " " + user.lastName;
            newRow.insertCell(2).textContent = user.email;
            newRow.insertCell(3).textContent = user.address.city;
            newRow.insertCell(4).textContent = user.address.postalCode;
            newRow.insertCell(5).textContent = user.phone;
        }

    } catch (err) {
        console.error(err);
    }
}

getUsers();