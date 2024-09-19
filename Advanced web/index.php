<?php
include 'include/header.php';
include 'classes/DB.php';
include 'classes/University.php';

$db = new DB("localhost", "root", "", "2023_final_exam");
$conn = $db->getConnection();

?>

<div class="jumbotron mt-4 " style="background:url(images/bg.jpg); background-size:cover; height:400px">
    <div class="container pt-5 mt-4">
        <h1 class="display-4"><i class="fas fa-exclamation-circle"></i> Login to add a University</h1>
        <a href="login.php"><button class="btn btn-lg btn-primary
    "><i class="fas fa-door-open    "></i> Login</button></a>
    </div>
</div>
<div class="container">
    <div class="row">
        <div class="col-md-9">
            <div class="row">
                <?php
                $sql = "SELECT * FROM universities";
                $result = $conn->query($sql);

                if ($result->num_rows > 0) {
                    while ($row = $result->fetch_assoc()) {
                        $id = $row['id'];
                        $name = $row['uni_name'];
                        $image = $row['uni_img'];
                        $description = $row['uni_summary'];
                        $students = $row['uni_students'];
                        $location = $row['uni_location'];
                        ?>
                        <div class="col-md-6 mt-3">
                            <div class="card">
                                <img class="card-img-top" src="<?php echo $image; ?>" alt=""
                                    style="height:275px;object-fit:cover;">
                                <div class="card-body">
                                    <a href="uni.php?id=<?php echo $id; ?>">
                                        <h5 class="card-title">
                                            <?php echo $name; ?>
                                        </h5>
                                    </a>
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
                                <button class="btn btn-primary btn-block"> Learn more</button>
                            </div>
                        </div>
                        <?php
                    }
                } else {
                    echo "No universities found.";
                }
                ?>
            </div>
        </div>
        <div class="col-md-3">
            <img src="images/vn.png" width="100%" alt="">
        </div>
    </div>
</div>

<?php
include 'include/footer.php';
?>