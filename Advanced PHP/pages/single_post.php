<?php include "includes/header.php"; ?>

<div class="container">
    <div class="col-md-9 offset-md-1 mt-4">
        <div class="card tweet-card">
            <div class="card-body">
                <a class="tweet-link" href="<?php echo ROOT . 'post/get/' . $post['id']; ?>">
                    <h5 class="tweet-title">
                        <?php echo $post['title']; ?>
                    </h5>
                </a>
                <p class="card-text tweet-text">
                    <?php echo $post['body']; ?>
                </p>
                <img src="<?php echo ROOT . 'public/' . $post['img_url']; ?>" class="img-fluid tweet-image"
                    alt="Tweet Image">

                <!-- Comment Section -->
                <div class="comments wider-comments">
                    <div class="d-flex flex-column align-items-center">
                        <h3>Comments</h3>
                        <form action="<?php Router::url('comment/create'); ?>" method="post" id="commentForm"
                            class="comment-form">
                            <div class="form-group">
                                <textarea name="comment" class="form-control comment-text" id="commentTextarea" rows="3"
                                    cols="100" style="width: 100%;"></textarea>
                            </div>
                            <input type="hidden" name="comment_post_id" class="comment_post_id"
                                value="<?php echo $post['id']; ?>">
                            <button type="submit" class="btn btn-primary mt-3 mb-3" name="submit"
                                style="width: 100%;"><i class="fa fa-check-circle"></i>Submit</button>
                        </form>
                    </div>
                    <hr>
                    <div class="comment-output">
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<script>
    let commentForm = document.getElementById('commentForm');
    let commentTextarea = document.getElementById('commentTextarea');
    let commentOutput = document.querySelector('.comment-output');
    let commentPostId = document.querySelector('.comment_post_id').value;

    commentForm.addEventListener('submit', function (event) {
        event.preventDefault();
        let commentText = commentTextarea.value;
        insertNewComment(commentText, commentPostId);
    });

    function fetchComments(id) {
        fetch('<?php Router::url("comment/get/") ?>' + id)
            .then(response => response.json())
            .then((data) => {
                let output = '';
                data.forEach((c) => {
                    output += `<p>${c.comment_text}</p><h5>User: ${c.user_id}</h5><hr>`;
                });
                commentOutput.innerHTML = output;
            });
    }


    function insertNewComment(text, id) {
        fetch('<?php Router::url("comment/create"); ?>', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            body: 'comment_text=' + text + '&comment_post_id=' + id
        })
            .then(response => response.json())
            .then((data) => {
                // Fetch the newly inserted comment data
                const newComment = data.comments[0];

                // Create the HTML markup for the new comment
                const commentMarkup = `
      <p>${newComment.comment_text}</p>
      <h5>User: ${newComment.user_id}</h5>
      <hr>
    `;

                // Append the new comment to the comment output container
                commentOutput.innerHTML += commentMarkup;

                // Clear the comment textarea
                commentTextarea.value = '';
            });
    }

</script>

<?php include "includes/footer.php"; ?>