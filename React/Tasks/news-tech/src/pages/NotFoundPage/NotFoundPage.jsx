import { useNavigate } from "react-router";

const NotFoundPage = () => {
  const navigateTo = useNavigate();
  const handleOnClick = () => {
    navigateTo("/home", { replace: true });
  };
  return (
    <>
      <div className="d-flex flex-column justify-content-center align-items-center vh-100 text-center px-3">
        <img
          src="src/assets/notFound.png"
          alt="Page Not Found"
          className="img-fluid mb-4 w-25"
        />

        <h1 className="fw-bold text-dark mb-2">404 - Page Not Found</h1>

        <p className="text-muted mb-4">
          Sorry, the page you are looking for doesn’t exist or has been moved.
        </p>

        <p onClick={handleOnClick} className="text-muted mb-4" role="button">
          Go to Home?
        </p>
      </div>
    </>
  );
};

export default NotFoundPage;
