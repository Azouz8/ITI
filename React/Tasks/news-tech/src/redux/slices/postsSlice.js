import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";

export const fetchPostsAsync = createAsyncThunk(
    "posts/fetchPosts",
    async () => {
        const response = await fetch("http://localhost:3000/posts");
        const data = await response.json();
        return data;
    }
);
export const addPostAsync = createAsyncThunk(
    "posts/addPost",
    async (newPost) => {
        const response = await fetch("http://localhost:3000/posts", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(newPost),
        });
        const data = await response.json();
        return data;
    }
);

export const updatePostAsync = createAsyncThunk(
    "posts/updatePost",
    async ({ id, updates }) => {
        const response = await fetch(`http://localhost:3000/posts/${id}`,
            {
                method: "PATCH",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(updates),
            })
        const data = await response.json();
        return data;
    }
)

const postsSlice = createSlice({
    name: "posts",
    initialState: {
        posts: [],
        search: "",
        loading: false,
        error: null,
    },
    reducers: {
        setSearch: (state, action) => {
            state.search = action.payload
        },
    },
    extraReducers: (builder) => {
        builder.addCase(fetchPostsAsync.pending, (state) => {
            state.loading = true;
            state.error = null;
        })
            .addCase(fetchPostsAsync.fulfilled, (state, action) => {
                state.loading = false;
                state.posts = action.payload;
            })
            .addCase(fetchPostsAsync.rejected, (state, action) => {
                state.loading = false;
                state.error = action.error.message;
            })
            .addCase(updatePostAsync.fulfilled, (state, action) => {
                const index = state.posts.findIndex((p) => p.id === action.payload.id);
                if (index !== -1) state.posts[index] = action.payload;
            })
            .addCase(updatePostAsync.rejected, (state, action) => {
                state.error = action.error.message;
            }).addCase(addPostAsync.fulfilled, (state, action) => {
                state.posts.unshift(action.payload); 
            })
            .addCase(addPostAsync.rejected, (state, action) => {
                state.error = action.error.message;
            })
    }
});

export const { setPosts, setSearch, setLoading, setError, addPost, updatePost } = postsSlice.actions;
export default postsSlice.reducer;