<?php
class University
{
    private $conn;

    public function __construct($conn)
    {
        $this->conn = $conn;
    }

    public function getUniversity($id)
    {
        $sql = "SELECT * FROM universities WHERE id = $id";
        $result = $this->conn->query($sql);

        if ($result->num_rows > 0) {
            $row = $result->fetch_assoc();
            return $row;
        } else {
            return false;
        }
    }

    public function deleteUniversity($id)
    {
        $sql = "DELETE FROM universities WHERE id = $id";

        if ($this->conn->query($sql) === TRUE) {
            return true;
        } else {
            return false;
        }
    }

    public function updateUniversity($id, $name, $description, $students, $location)
    {
        $sql = "UPDATE universities SET uni_name = '$name', uni_summary = '$description', uni_students = '$students', uni_location = '$location' WHERE id = $id";

        if ($this->conn->query($sql) === TRUE) {
            return true;
        } else {
            return false;
        }
    }


}
?>