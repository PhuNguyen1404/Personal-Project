<?php
include 'includes/header.php';
?>
<style>
    <?php include "style.css"; ?>
</style>

<section class="vh-130 gradient-custom">
    <div class="container py-5 h-100">
        <div class="row d-flex justify-content-center align-items-center h-100">
            <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                <div class="card bg-dark text-white">
                    <div class="card-body p-5 text-center">
                        <div class="mb-md-5 mt-md-4 pb-5">
                            <h2 class="fw-bold mb-2 text-uppercase">Sign Up</h2>
                            <p class="text-white-50 mb-5">Create a new account!</p>
                            <form action="<?php echo ROOT; ?>create/user" method="post">
                                <div class="form-group form-white mb-4">
                                    <input type="username" name="username" type="username"
                                        class="form-control form-control-lg" placeholder="UserName" />
                                </div>
                                <div class="form-group form-white mb-4">
                                    <input name="email" type="email" class="form-control form-control-lg"
                                        placeholder="Email" />
                                </div>
                                <div class="form-group form-white mb-4">
                                    <input name="password" type="password" class="form-control form-control-lg"
                                        placeholder="Password" />
                                </div>
                                <div class="form-group form-white mb-4">
                                    <input name="password-confirm" type="password" class="form-control form-control-lg"
                                        placeholder="Confirm Password" />
                                </div>
                                <button class="btn btn-outline-light btn-lg px-5" type="submit">Sign up</button>
                            </form>
                            <div class="d-flex justify-content-center text-center mt-4 pt-1">
                                <a href="#!" class="text-white"><i class="fab fa-facebook-f fa-lg"></i></a>
                                <a href="#!" class="text-white"><i class="fab fa-twitter fa-lg mx-4 px-2"></i></a>
                                <a href="#!" class="text-white"><i class="fab fa-google fa-lg"></i></a>
                            </div>
                        </div>
                        <div>
                            <p class="mb-0">Already have an account? <a href="<?php echo ROOT; ?>signin"
                                    class="text-white-50 fw-bold">Sign In</a>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>

<?php
include 'includes/footer.php';
?>