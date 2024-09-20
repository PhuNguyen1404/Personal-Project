<?php include "dbcon.php"; ?>
<?php include "session.php"; ?>
<?php define("ROOT", substr($_SERVER['PHP_SELF'], 0, -9)); ?>
<?php include "includes/header.php"; ?>


<?php
$user_id = $_SESSION['user_id'];
$username = $_POST['username'];
$realname = $_POST['realname'];
$gender = $_POST['gender'];
$address = $_POST['address'];
$birthdate = $_POST['birthdate'];
$status = $_POST['status'];
$work = $_POST['work'];
$custom = $_POST['custom'];


$conn->query("update user set user_name = '$username',real_name = '$realname',  gender='$gender',address='$address',
birthdate='$birthdate',status='$status',work='$work',custom='$custom' where id = '$user_id'
");

?>
<script>
    window.location = 'profile';
</script>
<?php include "includes/footer.php"; ?>