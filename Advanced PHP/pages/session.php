<?php
session_start();
$session_id = $_SESSION['user_id'];
$session_query = $conn->query("select * from user where id = '$session_id'");
$user_row = $session_query->fetch();
$username = $user_row['user_name'];
$image = $user_row['user_image'];
?>
