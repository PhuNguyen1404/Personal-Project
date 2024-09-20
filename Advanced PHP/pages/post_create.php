<?php include "pages/includes/header.php"; ?>

<div class="jumbotron">
    <div class="container post-tweet">
        <h1 class="display-4">Create a new post</h1>
        <hr class="my-4">
        <form method="post" action="<?php echo Router::url("post/create"); ?>" enctype="multipart/form-data">
            <div class="form-group">
                <label for="title">Post Title</label>
                <input id="title" class="form-control" type="text" name="title" placeholder="Title of your post...">
            </div>
            <div class="form-group">
                <label for="body">Post Body</label>
                <textarea id="body" class="form-control" name="body" rows="5"></textarea>
            </div>
            <div class="form-group">
                <label for="blog_img">Blog Image</label>
                <input id="blog_img" class="form-control" type="file" name="blog_img">
            </div>
            <button type="submit" name="create" class="btn btn-primary btn-lg btn-block"><i
                    class="fas fa-plus-circle"></i> Create Post</button>
        </form>
    </div>
</div>

<?php include "pages/includes/footer.php"; ?>