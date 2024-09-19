<?php
include 'include/header.php';
include "classes/DB.php";

$db = new DB("localhost", "root", "", "2023_final_exam");
$conn = $db->getConnection();


if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $name = $_POST['uni_name'];
    $image = $_FILES['meme_img']['name'];
    $description = $_POST['uni_summary'];
    $students = $_POST['uni_students'];
    $location = $_POST['uni_location'];

   // Process the image upload and move it to the desired location
   $targetDirectory = "images/";
   $targetFile = $targetDirectory . basename($image);
   move_uploaded_file($_FILES['meme_img']['tmp_name'], $targetFile);

   // Concatenate the image file name with the target directory
   $image = $targetDirectory . $image;

    // Insert the university details into the database
    $sql = "INSERT INTO universities (uni_name, uni_location, uni_students, uni_summary, uni_img)
            VALUES ('$name', '$location', '$students', '$description', '$image')";

    if ($conn->query($sql) === TRUE) {
        $message = "University created successfully.";
        $alertClass = "alert-success";
    } else {
        echo "Error creating university: " . $conn->error;
    }
}
?>

<div class="jumbotron jumbotron-fluid">
    <div class="container">
        <h1 class="display-4">Create a new University</h1>
        <hr class="my-4">
        <form method="post" action="create.php" enctype="multipart/form-data">
            <div class="form-group">
                <label for="uni_name">University Title</label>
                <input id="uni_name" class="form-control" type="text" name="uni_name"
                    placeholder="Title of your meme...">
            </div>
            <div class="form-group">
                <label for="uni_summary">University Body</label>
                <textarea id="uni_summary" class="form-control" name="uni_summary" rows="5"></textarea>
            </div>
            <div class="form-group">
                <label for="uni_location">University Location</label>
                <input id="uni_location" class="form-control" type="text" name="uni_location" placeholder="">
            </div>
            <div class="form-group">
                <label for="uni_students">University Student Count</label>
                <input id="uni_students" class="form-control" type="number" name="uni_students" placeholder="">
            </div>
            <div class="form-group">
                <label for="meme_img">University Image</label>
                <input id="meme_img" class="form-control" type="file" name="meme_img">
            </div>
            <button type="submit" name="create" class="btn btn-primary btn-lg btn-block">
                <i class="fas fa-plus-circle"></i> Create University
            </button>
        </form>
    </div>
</div>

<?php
include 'include/footer.php';
?>