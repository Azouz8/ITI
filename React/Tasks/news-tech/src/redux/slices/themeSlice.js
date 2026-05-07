import { createSlice } from "@reduxjs/toolkit";
document.body.setAttribute("data-theme", "dark");
let themeSlice = createSlice({
    name: "themeS",
    initialState: { isDark: true },
    reducers: {
        changeTheme: (state, action) => {
            state.isDark = !state.isDark
            document.body.setAttribute("data-theme", state.isDark ? "dark" : "light");
        }
    }
})

export let { changeTheme } = themeSlice.actions
export default themeSlice.reducer;
