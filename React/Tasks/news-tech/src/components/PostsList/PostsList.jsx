import { Component } from "react";
import axios from "axios";
import styles from "./PostsList.module.css";
import Post from "./../PostCard/PostCard";

class PostsList extends Component {
  constructor(props) {
    super(props);
    this.state = {
      posts: [],
      isLoading: true,
      error: null,
    };
  }
  componentDidMount() {
    axios.get("http://localhost:3000/posts")
      .then((res) => {
        this.setState({ posts: res.data, isLoading: false });
      })
      .catch((err) => {
        this.setState({ error: err.message, isLoading: false });
      });
  }

  componentDidUpdate(prevProps) {
    if (this.props.newPost && this.props.newPost !== prevProps.newPost) {
      this.setState((prevState) => ({
        posts: [this.props.newPost, ...prevState.posts],
      }));
    }
  }

  handleUpdatePost = (id, updatedData) => {
    axios.patch(`http://localhost:3000/posts/${id}`, updatedData)
      .then(() => {
        this.setState((prevState) => ({
          posts: prevState.posts.map((post) =>
            post.id === id ? { ...post, ...updatedData } : post
          ),
        }));
      })
      .catch((err) => console.error("Failed to update post", err));
  };

  render() {
    const { posts, isLoading, error } = this.state;
    if (isLoading) return <p>Loading Posts.....</p>;
    if (error) return <p>Something went wrong: {error}</p>;
    return (
      <div className={styles.list}>
        {posts.map((post) => (
          <Post
            key={post.id}
            id={post.id}
            title={post.title}
            description={post.description}
            imageUrl={post.imgUrl}
            likeCount={post.likeCount}
            dislikeCount={post.dislikeCount}
            commentCount={post.commentCount}
            shareCount={post.shareCount}
            onUpdate={this.handleUpdatePost}
          />
        ))}
      </div>
    );
  }
}

// const CardList = () => {
//   const [cardData, setCardData] = useState([
//     { id: 1, title: "Card 1", description: "This is Desc 1" },
//     { id: 2, title: "Card 2", description: "This is Desc 2" },
//     { id: 3, title: "Card 3", description: "This is Desc 3" },
//     { id: 4, title: "Card 4", description: "This is Desc 4" },
//     { id: 5, title: "Card 5", description: "This is Desc 5" },
//     { id: 6, title: "Card 6", description: "This is Desc 6" },
//   ]);
//   return (
//     <div className="card-list">
//       {cardData.map((card) => (
//         <Card
//           key={card.id}
//           id={card.id}
//           title={card.title}
//           description={card.description}
//         />
//       ))}
//     </div>
//   );
// };

export default PostsList;
