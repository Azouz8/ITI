window.onload = function () {
  if (!window.localStorage) {
    window.localStorage = {
      setItem: function (key, value) {
        if (arguments.length !== 2)
          throw new Error("U must pass 2 params to setItem");
        setCookie(key, value.toString());
      },
      getItem: function (key) {
        if (arguments.length !== 1)
          throw new Error("U must pass only one param to getItem");
        return getCookie(key);
      },
      removeItem: function (key) {
        if (arguments.length !== 1)
          throw new Error("U must pass only one param to removeItem");
        deleteCookie(key);
      },
      clear: function () {
        let cookies = allCookieList();
        for (let key in cookies) {
          deleteCookie(key);
        }
      },
    };
  }

  window.localStorage.setItem("username", "ali");
  window.localStorage.setItem("email", "ali@gmail.com");
  window.localStorage.setItem("age", "25");
  console.log(window.localStorage.getItem("username"));
  console.log(window.localStorage.getItem("email"));
  console.log(window.localStorage.getItem("age"));
  window.localStorage.removeItem("email");
  console.log(window.localStorage.getItem("email"));
  console.log(window.localStorage);
  window.localStorage.clear();
  console.log(window.localStorage.getItem("username"));
};
