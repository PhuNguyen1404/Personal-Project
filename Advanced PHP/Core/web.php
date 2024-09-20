<?php


Router::get('test', function () {
    echo '<h1>TESTING</H1>';
});

Router::get('', function () {
    $homepage = new HomeController;
    $homepage->index();
});

Router::post("create/user", function () {
    $user = new UserController;
    $user->create();
});

Router::get("post/create", function () {
    $post = new PostController();
    $post->getCreate();
});

Router::get("user/post/{id}", function ($id) {
    $post = new PostController();
    $post->fetchUserPost($id);

});
Router::get("user/get/{id}", function ($id) {
    $post = new PostController;
    $post->fetchUserPost($id);
});

Router::post("post/create", function () {
    $post = new PostController();
    $post->create();
});

Router::get("signin", function () {
    $user = new UserController;
    $user->getSignIn();
});

Router::get("signup", function () {
    $user = new UserController;
    $user->getSignUp();
});

Router::post("signin", function () {
    $user = new UserController;
    $user->validateLogin();
});

Router::get("logout", function () {
    $_SESSION = [];
    session_destroy();
    header("Location:" . ROOT);
});

Router::get("post/get/{id}", function ($id) {
    $post = new PostController;
    $post->getPost($id);
});

Router::get("post/all", function () {
    $post = new PostController;
    $post->getAllPosts();
});

Router::post('comment/create', function () {
    $commentController = new CommentController(DB::getConn());
    $commentController->create();
});

Router::get('comment/get/{id}', function ($id) {
    $commentController = new CommentController(DB::getConn());
    $commentController->getComments($id);
});


if (Router::$found === false) {
    include "pages/_404.php";
};

?>