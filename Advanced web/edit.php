<?php
include 'include/header.php';
include 'classes/DB.php';
include 'classes/University.php';

$db = new DB("localhost", "root", "", "2023_final_exam");
$conn = $db->getConnection();

$universityObj = new University($conn);

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    if (isset($_POST['update_university'])) {
        $id = $_POST['id'];
        $name = $_POST['uni_name'];
        $image = $_FILES['uni_img']['name'];
        $description = $_POST['uni_summary'];
        $students = $_POST['uni_students'];
        $location = $_POST['uni_location'];

        // Process the image upload and move it to the desired location
        $targetDirectory = "images/";
        $targetFile = $targetDirectory . basename($image);
        move_uploaded_file($_FILES['uni_img']['tmp_name'], $targetFile);

        // Update the university details in the database
        $updated = $universityObj->updateUniversity($id, $name, $image, $description, $students, $location);

        if ($updated) {
            echo "<div class='alert alert-success'>University updated successfully.</div>";
        } else {
            echo "<div class='alert alert-danger'>Error updating university.</div>";
        }
    }
}

if (isset($_GET['id'])) {
    $universityId = $_GET['id'];
    $university = $universityObj->getUniversity($universityId);

    if ($university) {
        $id = $university['id'];
        $name = $university['uni_name'];
        $image = $university['uni_img'];
        $description = $university['uni_summary'];
        $students = $university['uni_students'];
        $location = $university['uni_location'];
        ?>
        <div class="container mt-4">
            <h1>Edit University</h1>
            <hr>
            <form method="POST" action="" enctype="multipart/form-data">
                <input type="hidden" name="id" value="<?php echo $id; ?>">

                <div class="form-group">
                    <label for="uni_name">University Title</label>
                    <input id="uni_name" class="form-control" type="text" name="uni_name" value="<?php echo $name; ?>">
                </div>

                <div class="form-group">
                    <label for="uni_summary">University Body</label>
                    <textarea id="uni_summary" class="form-control" name="uni_summary" rows="5"><?php echo $description; ?></textarea>
                </div>

                <div class="form-group">
                    <label for="uni_location">University Location</label>
                    <input id="uni_location" class="form-control" type="text" name="uni_location" value="<?php echo $location; ?>">
                </div>

                <div class="form-group">
                    <label for="uni_students">University Student Count</label>
                    <input id="uni_students" class="form-control" type="number" name="uni_students" value="<?php echo $students; ?>">
                </div>

                <div class="form-group">
                    <label for="uni_img">University Image</label>
                    <input id="uni_img" class="form-control" type="file" name="uni_img">
                </div>

                <button type="submit" name="update_university" class="btn btn-primary">Update University</button>
            </form>
        </div>
        <?php
    } else {
        echo "University not found.";
    }
} else {
    echo "Invalid university ID.";
}

include 'include/footer.php';
?>
