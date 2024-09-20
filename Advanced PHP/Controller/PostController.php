<?php


class PostController extends Controller
{
    // properties
    public $post_id;
    public $post_user_id;
    public $post = [];
    public $posts = [];
    public $errors = [];
    public $id;

    // constructor
    public function __construct()
    {
        parent::__construct();
    }

    // methods
    public function getPost($id)
    {
        $this->id = $id;
        $postModel = new Post($this->conn);
        $post = $postModel->fetchPost($this->id);
        include "pages/single_post.php";
    }
    public function fetchUserPost($id)
    {
        $this->id = $id;
        $postModel = new Post($this->conn);
        $posts = $postModel->fetchID($this->id);
        include "pages/blog.php";
    }
    public function getAllPosts()
    {
        $postModel = new Post($this->conn);
        $posts = $postModel->fetchAll();
        include "pages/blog.php";
    }

    public function getCreate()
    {
        //is user logged in?
        if (!Auth::loggedIn()) {
            header("Location: " . ROOT . "signin");
            //if not redirect to login
        } else {
            //else include views 
            include "pages/post_create.php";
        }

    }

    public function create()
    {
        //is user logged in?
        if (!Auth::loggedIn()) {
            header("Location: " . ROOT . "signin");
            //if not redirect to login
        } else {
            //else process the post
            if (empty($this->req['title']) || empty($this->req['body'])) {
                header("Location: " . ROOT . "post/create");
            } else {
                $post = new Post($this->conn);
                $result = $post->create($this->req, $this->files);
                if ($result !== false) {
                    header("Location: " . ROOT . "post/get/" . $result);
                } //$this->req == $_POST
            }
        }
    }
}


?>