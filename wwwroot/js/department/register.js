document.addEventListener("DOMContentLoaded", () => {
  var address = document.getElementById("address");

  var price = document.getElementById("price");

  var phoneNumber = document.getElementById("phoneNumber");

  var acreage = document.getElementById("acreage");

  var description = document.getElementById("description");
  var inputFiles = document.getElementById("files");
  var groupId = document.getElementById("departmentSelect");

  phoneNumber.addEventListener("focusout", () => {
    validPhone(phoneNumber.value, msgPhoneNumber);
  });
  phoneNumber.addEventListener("keydown", () => {
    hideMess(msgPhoneNumber);
  });

  btnRegister.addEventListener("click", function (e) {
    e.preventDefault();

    if (!validPhone(phoneNumber.value, msgPhoneNumber)) {
      return;
    }

    const data = {
      address: address.value,
      price: price.value,
      phoneNumber: phoneNumber.value,
      acreage: acreage.value,
      description: description.value,
      images: inputFiles.files,
      groupId: groupId.value,
    };

    var jsonData = JSON.stringify(data);

    CustomRequest.postForm({
      url: "https://localhost:5001/Department/Register",
      addToken: true,
      data: data,
      callback: (response) => {
        ToastMessage.show({
          type: "success",
          title: "Thành công!",
        });
        isConfirm();
      },
    });
  });
});

const validPhone = (value, mess) => {
  if (value === "") {
    mess.textContent = "Vui lòng nhập số điện thoại của bạn";
    mess.style.display = "block";
    return false;
  }

  return true;
};

const hideMess = (mess) => {
  mess.textContent = "";
  mess.style.display = "none";
};

function loadJsonData() {
  var xhr = new XMLHttpRequest();
  var xhr = new XMLHttpRequest();
  xhr.overrideMimeType("application/json");
  xhr.open(
    "GET",
    new URL(
      "https://localhost:5001/data/DepartmentGroup.json",
      document.baseURI
    ).href,
    true
  );
  xhr.onreadystatechange = function () {
    if (xhr.readyState === 4 && xhr.status === 200) {
      var data = JSON.parse(xhr.responseText);
      populateSelectBox(data);
    }
  };
  xhr.send();
}

// Thêm các mục vào select box khi đọc dữ liệu thành công
function populateSelectBox(data) {
  var selectBox = document.getElementById("departmentSelect");
  data.forEach(function (item) {
    var option = document.createElement("option");
    option.value = item.Id; // Lưu Id của mục vào giá trị của option
    option.textContent = item.Name; // Hiển thị tên của mục là nội dung của option
    selectBox.appendChild(option);
  });
}

// Xử lý sự kiện khi người dùng chọn một mục trong select box
document
  .getElementById("departmentSelect")
  .addEventListener("change", function () {
    var selectedId = this.value; // Lấy giá trị Id của mục đã chọn
    console.log("Selected Id: " + selectedId);
  });

// Gọi hàm để load dữ liệu vào select box khi trang đã tải xong
document.addEventListener("DOMContentLoaded", function () {
  loadJsonData();
});

function clearDataRegisDepartment() {
  document.getElementById("address").value = "";

  document.getElementById("price").value = 0;

  document.getElementById("phoneNumber").value = "";

  document.getElementById("acreage").value = "";

  document.getElementById("description").value = "";

  document.getElementById("files").value = "";

  document.getElementById("departmentSelect").groupId.value = "";
}

function isConfirm() {
  var isConfirmed = window.confirm("Bạn có muốn tạo department mới không?");
  if (isConfirmed) {
    clearDataRegisDepartment();
  } else {
    window.location.href = "https://localhost:5001/";
  }
}
