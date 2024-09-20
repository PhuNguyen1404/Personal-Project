<?php
class CommentController extends Comment
{
    public function __construct($conn)
    {
        parent::__construct($conn);
    }

    public function create()
    {
        if ($_SERVER['REQUEST_METHOD'] == 'POST') {
            $commentText = $_POST['comment_text'];
            $commentPostId = $_POST['comment_post_id'];
            $userId = 1; // Update the user ID as needed

            // Insert the comment
            $this->insertComment($commentText, $commentPostId, $userId);

            // Redirect back to the post page
            Router::redirect('post/get/' . $commentPostId);
        }
    }

    public function getComments($postId)
    {
        // Fetch comments for the given post ID
        $comments = $this->getComments($postId);

        // Return the comments as JSON response
        echo json_encode($comments);
        exit;
    }
}
