<?php include "dbcon.php"; ?>
<?php include "session.php"; ?>
<?php define("ROOT", substr($_SERVER['PHP_SELF'], 0, -9)); ?>




<div class="row ">
	<div class="col-md-2">
		<hr>
		<center><img class="pp" src="<?php echo $_SESSION['user_img']; ?>" height="140" width="160"></center>
		<hr>
	</div>
	<div class="col-md-5">
		<hr>
		<p>Personal Info</p>
		<?php
		$query = $conn->query("select * from user where id = '$_SESSION[user_id]'");
		$row = $query->fetch();
		$id = $row['id'];
		var_dump($id);
		?>

		<hr>
		<p>Name:

			<?php echo $row['user_name']; ?><span class="margin-p"></span>Gender:
			<?php echo $row['gender']; ?>
		</p>
		<hr>
		<p>Real Name:
			<?php echo $row['real_name']; ?>
		</p>
		<hr>
		<p>Address:
			<?php echo $row['address']; ?>
		</p>
		<hr>
		<p>Gender:
			<?php echo $row['gender']; ?>
		</p>
		<hr>
		<p>Birthdate:
			<?php echo $row['birthdate']; ?>
		</p>
		<hr>
		<p>Status:
			<?php echo $row['status']; ?>
		</p>
		<hr>
		<p>Work:
			<?php echo $row['work']; ?>
		</p>
		<hr>
		<p>Something more:
			<?php echo $row['custom']; ?>
		</p>
	</div>
	<div class="col-md-5">
		<form method="post" action="editProfile.php">
			<textarea name="edit" placeholder="Edit your profile"></textarea>
			<br>
			<hr>
			<button class="btn btn-success"><i class="icon-share"></i> Edit </button>
		</form>
	</div>
</div>
