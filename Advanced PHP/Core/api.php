<?php
include "core/db.php";
include "models/Comment.php";

// Create a database instance
$db = DB::createInstance();

// Connect to the database
$db->connect("localhost", "root", "", "2023_itec_blog");

// Get the database connection
$conn = $db->getConn();

if (isset($_POST['comment_post_id'])) {
    $comment = new Comment($conn);
    $comments = $comment->getComments($_POST['comment_post_id']);
    echo json_encode($comments);
    exit;
}

if (isset($_POST['comment_text']) && isset($_POST['comment_post_id'])) {
    $comment = new Comment($conn);
    $comment->insertComment($_POST['comment_text'], $_POST['comment_post_id'], 1); // Adjust the user_id as needed
    $comments = $comment->getComments($_POST['comment_post_id']);
    echo json_encode($comments);
    exit;
}
?>