<form id="comment-form" action="<?php echo ROOT . 'add_comment.php'; ?>" method="post">
    <input type="hidden" name="comment_post_id" value="<?php echo $post['id']; ?>">
    <div class="form-group">
        <label for="comment-text">Add a comment:</label>
        <textarea class="form-control" id="comment-text" name="comment_text" rows="3" required></textarea>
    </div>
    <button type="submit" class="btn btn-primary">Submit Comment</button>
</form>
