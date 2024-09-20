<?php
session_start();
if (!isset($_SESSION['logged_in'])) {
    $_SESSION['logged_in'] = false;
}
define("ROOT", substr($_SERVER['PHP_SELF'], 0, -9));

include "core/db.php";
DB::createInstance();
DB::connect("localhost", "root", "", "2023_itec_blog");

include "Controller/Controller.php";
include "Controller/HomePage.php";
include "Controller/UserController.php";
include "Controller/PostController.php";
include "models/Comment.php";
include "Controller/CommentController.php";
include "models/Post.php";
include "models/User.php";
include "ultilities/Auth.php";
include "Core/Router.php";
include "Core/web.php";

?>
