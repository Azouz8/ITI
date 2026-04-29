import { Component } from "react";
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
    fetch("http://localhost:3000/posts")
      .then((res) => {
        if (!res.ok) throw new Error("Failed to fetch Data");
        return res.json();
      })
      .then((data) => {
        this.setState({ posts: data, isLoading: false });
      })
      .catch((err) => {
        this.setState({ error: err.message, isLoading: false });
      });
  }
  render() {
    const { posts, isLoading, error } = this.state;
    if (isLoading) return <p>Loading Posts.....</p>;
    if (error) return <p>Something went wrong: {error}</p>;
    return (
      <div className={styles.list}>
        {this.state.posts.map((post) => (
          <Post
            key={post.id}
            id={post.id}
            title={post.title}
            description={post.description}
            imageUrl={post.imgUrl}
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
