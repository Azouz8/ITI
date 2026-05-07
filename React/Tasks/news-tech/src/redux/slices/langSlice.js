import { createSlice } from "@reduxjs/toolkit";

let langSlice = createSlice({
    name: "langS",
    initialState: { language: "EN" },
    reducers: {
        changeLang: (state, action) => {
            state.language = action.payload
        }
    }
})

export let { changeLang } = langSlice.actions
export default langSlice.reducer;