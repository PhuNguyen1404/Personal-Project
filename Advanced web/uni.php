<?php
include 'include/header.php';
include 'classes/DB.php';
include 'classes/University.php';

$db = new DB("localhost", "root", "", "2023_final_exam");
$conn = $db->getConnection();

$universityObj = new University($conn);

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

        if ($_SERVER['REQUEST_METHOD'] === 'POST') {
            if (isset($_POST['delete'])) {
                $deleted = $universityObj->deleteUniversity($id);

                if ($deleted) {
                    $message = "University deleted successfully.";
                    $alertClass = "alert-success";
                    header("Location: index.php");
                    exit;
                } else {
                    $message = "Error deleting university.";
                    $alertClass = "alert-danger";
                }
            } elseif (isset($_POST['update'])) {
                $name = $_POST['uni_name'];
                $description = $_POST['uni_summary'];
                $students = $_POST['uni_students'];
                $location = $_POST['uni_location'];

                $updated = $universityObj->updateUniversity($id, $name, $description, $students, $location);

                if ($updated) {
                    $message = "University updated successfully.";
                    $alertClass = "alert-success";
                    // Refresh the page to reflect the updated data
                    header("Location: uni.php?id=$id");
                    exit;
                } else {
                    $message = "Error updating university.";
                    $alertClass = "alert-danger";
                }
            }
        }

        ?>
        <div class="container mt-4">
            <div class="card">
                <img class="card-img-top" src="<?php echo $image; ?>" alt="" style="height:275px;object-fit:cover;">
                <div class="card-body">
                    <h5 class="card-title">
                        <?php echo $name; ?>
                    </h5>
                    <p class="card-text">
                        <?php echo $description; ?>
                    </p>
                </div>
                <div class="card-footer">
                    <i class="fas fa-users"></i> Students :
                    <?php echo $students; ?>
                    <i class="fas fa-map-marker"></i> Location :
                    <?php echo $location; ?>
                </div>
                <form method="POST" action="">
                    <div class="form-group">
                        <label for="uni_name">University Title</label>
                        <input id="uni_name" class="form-control" type="text" name="uni_name" value="<?php echo $name; ?>">
                    </div>
                    <div class="form-group">
                        <label for="uni_summary">University Body</label>
                        <textarea id="uni_summary" class="form-control" name="uni_summary"
                            rows="5"><?php echo $description; ?></textarea>
                    </div>
                    <div class="form-group">
                        <label for="uni_location">University Location</label>
                        <input id="uni_location" class="form-control" type="text" name="uni_location"
                            value="<?php echo $location; ?>">
                    </div>
                    <div class="form-group">
                        <label for="uni_students">University Student Count</label>
                        <input id="uni_students" class="form-control" type="number" name="uni_students"
                            value="<?php echo $students; ?>">
                    </div>
                    <button type="submit" name="update" class="btn btn-primary btn-lg btn-block">
                        <i class="fas fa-edit"></i> Update University
                    </button>
                    <button type="submit" name="delete" class="btn btn-danger btn-lg btn-block">
                        <i class="fas fa-trash"></i> Delete University
                    </button>
                </form>
            </div>
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