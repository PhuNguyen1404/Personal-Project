<?php
include 'includes/header.php';
?>

<div class="container">
  <div class="row">
    <div class="col-md-9 offset-md-1 mt-4">
      <h1 class="text-center">Twitter News Feed</h1>
      <hr>
      <div class="card tweet-card">
        <?php if (!empty($posts)): ?>
          <?php foreach ($posts as $post): ?>
            <div class="card-body">
              <h5 class="card-title tweet-author">
                <?php echo $post['user_name']; ?>
              </h5>
              <a class="tweet-link" href="<?php echo ROOT . 'post/get/' . $post['id']; ?>">
                <h5 class="tweet-title">
                  <?php echo $post['title']; ?>
                </h5>
              </a>
              <p class="card-text tweet-text">
                <?php echo $post['body']; ?>
              </p>
              <img src="<?php echo ROOT . 'public/' . $post['img_url']; ?>" class="img-fluid tweet-image" alt="Tweet Image">
            </div>
          <?php endforeach; ?>
        <?php endif; ?>
      </div>
    </div>
  </div>
</div>

<?php
include "includes/loading.php";
include 'includes/footer.php';
?>