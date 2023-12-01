document.addEventListener("DOMContentLoaded", () => {
  var form = { pageIndex: 1, pageSize: 10, dto: { status: 0 } };
  loadView(form);
});

const loadView = (form) => {
  setTimeout(() => {
    CustomRequest.postForm({
      url: "https://localhost:5001/Department/AdminSearchReview",
      addToken: true,
      data: form,
      callback: (response) => {
        var data = JSON.parse(response);
        createDepartmentItems(data);
      },
    });
  }, 500);
};

const createDepartmentItems = (data) => {
  var departmentItems = document.getElementById("departmentReviewContainer");
  if (departmentItems) {
    departmentItems.innerHTML = "";
    for (let i = 0; i < data.length; i++) {
      const item = createDepartmenttem(i, data[i]);
      departmentItems.insertAdjacentHTML("beforeend", item);
    }
  }
};

const createDepartmenttem = (index, data) => {
  const image = data.images && data.images.length ? data.images[0].path : "";

  var itemContent = `
    <div id="deparment-${data.id}" class="department-review-row">
        <div class="left">
          <a class="detail-image" href="/Department/Detail/${data.id}">
            <img src="https://localhost:5001/images/departments/${image}" alt="Department">
          </a>
        </div>
        <div class="middle">
            <p class="address">${data.address}</p>
            <p class="price">${data.price} VNĐ</p>
        </div>
        <div class="right">
            <button onclick="cancelDepartment(${data.id})" class="btn btn-danger">Hủy bỏ</button>
            <button onclick="confirmDepartment(${data.id})" class="btn btn-success">Xác nhận</button>
        </div>
    </div>
    `;

  return itemContent;
};

const confirmDepartment = (id) => {
  confirm(id, 2); // 2 là xác nhận
  var form = { pageIndex: 1, pageSize: 10, dto: { status: 0 } };
  loadView(form);
};

const cancelDepartment = (id) => {
  confirm(id, 1); // từ chối
  var form = { pageIndex: 1, pageSize: 10, dto: { status: 0 } };
  loadView(form);
};

const confirm = (id, status) => {
  var form = { id: id, status: status };
  CustomRequest.postForm({
    url: "https://localhost:5001/Department/Confirm",
    addToken: true,
    data: form,
    callback: (response) => {
      ToastMessage.show({
        type: "success",
        title: "Thành công!",
        message: "Cập nhập thành công",
      });
    },
  });
};
