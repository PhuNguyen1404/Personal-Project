<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <meta name="Description" content="Enter your description here" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.6.0/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css">
    <link rel="stylesheet" href="<?php echo ROOT; ?>public/css/style.css?v=<?php echo time(); ?>">
    <title>Express your feeling</title>
</head>

<body>
    <nav class="navbar navbar-expand-lg">
        <div class="container">
            <a class="navbar-brand text-white" href="<?php echo ROOT; ?> "><i
                    class="fa fa-graduation-cap fa-lg mr-2"></i>BLOG</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#nvbCollapse"
                aria-controls="nvbCollapse">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="nvbCollapse">
                <ul class="navbar-nav ml-auto">
                    <li class="nav-item pl-1">
                        <a class="nav-link" href="<?php echo ROOT; ?> "><i class="fas fa-home fa-fw mr-1"></i>Home</a>
                    </li>
                    <li class="nav-item pl-1">
                        <a class="nav-link" href="<?php echo ROOT; ?>post/all"><i
                                class="fas fa-th-list fa-fw mr-1"></i>Blog</a>
                    </li>

                    <li class="nav-item pl-1">
                        <a class="nav-link" href="<?php echo ROOT; ?>post/create"><i
                                class="fas fa-user-plus fa-fw mr-1"></i>Create post</a>
                    </li>
                    <?php if ($_SESSION['logged_in']): ?>
                        <li class="nav-item">
                            <a class="nav-link" href="<?php echo ROOT . 'user/get/' . $_SESSION['user_id']; ?>"><i
                                    class="fas fa-user"></i>
                                <?php echo $_SESSION['user_name']; ?>
                            </a>
                        </li>
                        <li class="nav-item pl-1">
                            <a class="nav-link" href="<?php echo ROOT; ?>pages/profile"><i class="fas fa-user"></i> My
                                Profile</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="<?php echo ROOT; ?>logout"><i
                                    class="fa fa-sign-in-alt fa-fw mr-1 fa-rotate-180"></i>Logout</a>
                        </li>
                    <?php else: ?>
                        <li class="nav-item pl-1">
                            <a class="nav-link" href="<?php echo ROOT; ?>signin"><i
                                    class="fa fa-sign-in-alt fa-fw mr-1"></i>Login</a>
                        </li>
                    <?php endif; ?>
                </ul>
            </div>
        </div>
    </nav>