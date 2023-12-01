var detail = {
  address: "123 Phố ABC, Quận XYZ, TP. ABC",
  price: 1500000,
  phoneNumber: "0123456789",
  roomArea: 30,
  status: "Đã thuê",
  description: "Mô tả về phòng trọ",
  latitude: 10.123456,
  longitude: 106.654321,
  availability: true,
  createAt: "2023-07-16T10:30:00Z",
  images: [
    "https://images.unsplash.com/photo-1575936123452-b67c3203c357?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8aW1hZ2V8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60",
    "https://images.unsplash.com/photo-1575936123452-b67c3203c357?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8aW1hZ2V8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60",
    "https://images.unsplash.com/photo-1575936123452-b67c3203c357?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8aW1hZ2V8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60",
    "https://images.unsplash.com/photo-1575936123452-b67c3203c357?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8aW1hZ2V8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60",
    "https://images.unsplash.com/photo-1575936123452-b67c3203c357?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8aW1hZ2V8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60",
    "https://images.unsplash.com/photo-1575936123452-b67c3203c357?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8aW1hZ2V8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60",
  ],
};

// Cập nhật giá trị vào các phần tử HTML
// document.getElementById("create-date").textContent = formatDate(
//   detail.createAt
// );
// document.getElementById("address").textContent = detail.address;
// document.getElementById("price").textContent = formatCurrency(detail.price);
// document.getElementById("phone-number").textContent = detail.phoneNumber;
// document.getElementById("room-area").textContent = detail.roomArea + " m²";
// document.getElementById("status").textContent = detail.status;
// document.getElementById("description").textContent = detail.description;
// document.getElementById("latitude").textContent = detail.latitude;
// document.getElementById("longitude").textContent = detail.longitude;
// document.getElementById("availability").textContent = detail.availability
//   ? "Có sẵn"
//   : "Không có sẵn";

// // Hiển thị các hình ảnh
// var imageContainer = document.getElementById("image-container");
// detail.images.forEach(function (imageUrl) {
//   var imgElement = document.createElement("img");
//   imgElement.src = imageUrl;
//   imageContainer.appendChild(imgElement);
// });

// // Hàm định dạng ngày tháng
// function formatDate(dateString) {
//   var date = new Date(dateString);
//   return date.toLocaleDateString("vi-VN");
// }

// // Hàm định dạng tiền tệ
// function formatCurrency(amount) {
//   return new Intl.NumberFormat("vi-VN", {
//     style: "currency",
//     currency: "VND",
//   }).format(amount);
// }

// new

document.addEventListener("DOMContentLoaded", function () {
  setTimeout(() => {
    var form = { page: 1, limit: 3 };
    CustomRequest.postForm({
      url: "https://localhost:5001/Department/Page",
      addToken: false,
      data: form,
      callback: (response) => {
        var data = JSON.parse(response);
        createSimilarItems(data);
      },
    });
  }, 500);
});

const createSimilarItems = (data) => {
  var similarItems = document.getElementById("items-container");
  if (similarItems) {
    similarItems.innerHTML = "";
    for (let i = 0; i < data.length; i++) {
      console.log(data[i]);
      const item = createSimilarItem(i, data[i]);
      similarItems.insertAdjacentHTML("beforeend", item);
    }
  }
};

const createSimilarItem = (index, data) => {
  var images = data.images;
  var itemContent = `
  <div class="item">
    <a href="${data.id}">
      <img src="https://localhost:5001/images/departments/${images[0].path}" alt="Department">
    </a>
  </div>
  `;

  return itemContent;
};

const storedValue = localStorage.getItem("username");
const modelUsername = document
  .getElementById("editButton")
  .getAttribute("data-username");

if (storedValue === modelUsername) {
  document.getElementById("editButton").style.display = "block";
} else {
  document.getElementById("editButton").style.display = "none";
}

document.getElementById("editButton").addEventListener("click", function () {
  fillDataModal();
});

const fillDataModal = (data) => {
  model = document.getElementById("editButton");
  data = {
    address: model.getAttribute("data-address"),
    description: model.getAttribute("data-description"),
    acreage: model.getAttribute("data-acreage"),
    groupId: model.getAttribute("data-groupId"),
    phoneNumber: model.getAttribute("data-phone"),
    price: model.getAttribute("data-price"),
    isAvailable: model.getAttribute("data-isAvailable") == "True" ? 1 : 0,
  };

  document.getElementById("description").value = data["description"];
  document.getElementById("price").value = data["price"];
  document.getElementById("address").value = data["address"];
  document.getElementById("acreage").value = data["acreage"];
  document.getElementById("phoneNumber").value = data["phoneNumber"];
  document.getElementById("departmentSelect").value = data["groupId"];
  document.getElementById("departmentAvaliable").value = data["isAvailable"];
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
  });

// Gọi hàm để load dữ liệu vào select box khi trang đã tải xong
document.addEventListener("DOMContentLoaded", function () {
  loadJsonData();
});

function updateDepartment(id) {
  var address = document.getElementById("address");

  var price = document.getElementById("price");

  var phoneNumber = document.getElementById("phoneNumber");

  var acreage = document.getElementById("acreage");

  var description = document.getElementById("description");
  var groupId = document.getElementById("departmentSelect");
  var isAvailable = document.getElementById("departmentAvaliable");

  phoneNumber.addEventListener("focusout", () => {
    validPhone(phoneNumber.value, msgPhoneNumber);
  });
  phoneNumber.addEventListener("keydown", () => {
    hideMess(msgPhoneNumber);
  });

  if (!validPhone(phoneNumber.value, msgPhoneNumber)) {
    return;
  }
  const data = {
    address: address.value,
    price: price.value,
    phoneNumber: phoneNumber.value,
    acreage: acreage.value,
    description: description.value,
    groupId: groupId.value,
    isAvailable: isAvailable.value == 1 ? true : false,
  };
  CustomRequest.postForm({
    url: "https://localhost:5001/Department/Update/" + id,
    addToken: true,
    data: data,
    callback: (response) => {
      ToastMessage.show({
        type: "success",
        title: "Thành công!",
      });
      window.location.href = "https://localhost:5001/Department/Detail/" + id;
    },
  });
}

const validPhone = (value, mess) => {
  if (value === "") {
    mess.textContent = "Vui lòng nhập số điện thoại của bạn";
    mess.style.display = "block";
    return false;
  }

  return true;
};
