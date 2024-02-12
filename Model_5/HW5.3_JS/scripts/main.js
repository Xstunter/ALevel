function clickOnPagination(index) {
    console.log("click - " + index)
    fetchRegresUsers(index);
}

function clickOnPaginationResources(index){
    console.log("click - " + index)
    fetchRegresResources(index);
}

class User{
    id;
    avatar;
    email;
    first_name;
    last_name;

    constructor(id,avatar,email,first_name,last_name){
        this.id = id;
        this.avatar = avatar;
        this.email = email;
        this.first_name = first_name;
        this.last_name = last_name;
    }
}

class UsersResponse{
    page;
    per_page;
    total;
    total_pages;
    data;

    constructor(page,per_page,total,total_pages,data){
        this.page = page;
        this.per_page = per_page;
        this.total = total;
        this.total_pages = total_pages;
        this.data = data;
        
        const dataArray = [];

        data.forEach(element => {
            dataArray.push(
                new User(
                    element.id,
                    element.avatar,
                    element.email,
                    element.first_name,
                    element.last_name
                )
            )
        })

        
    }
}

class Support{
    url;
    text;

    constructor(url, text){
        this.url = url;
        this.text = text;
    }
}

class Resources{
    id;
    name;
    year;
    color;
    pantone_value;

    constructor(id,name,year,color,pantone_value){
        this.id = id;
        this.name = name;
        this.year = year;
        this.color = color;
        this.pantone_value = pantone_value;
    }
}

class ResourcesResponse{
    
    data;
    support;

    constructor(data,support){ 
        this.data = new Resources(
                data.id,
                data.name,
                data.year,
                data.color,
                data.pantone_value
        );
        this.support = new Support(
                support.url,
                support.text
        );

    }
}

function fetchRegresUsers(pageNumber){

    const regres = "https://reqres.in"

    fetch(`${regres}/api/users?page=${pageNumber}`)
        .then(async response => {
            const bodyObject = await response.json();
            console.log(bodyObject);
            const usersResponse = new UsersResponse(
                bodyObject.page,
                bodyObject.per_page,
                bodyObject.total,
                bodyObject.total_pages,
                bodyObject.data
            );

            const tableBody = document.getElementById('box');

            // Отримуємо всі рядки (tr) в таблиці, починаючи з другого
            const rowsToRemove = Array.from(tableBody.querySelectorAll('thead:not(:first-child)'));
            
            // Видаляємо всі ці рядки
            rowsToRemove.forEach(row => row.remove());

            usersResponse.data.forEach(x => {
                const row = document.createElement('thead');
                row.innerHTML = `
                <tr>
                    <td>${x.id}</td>
                    <td>${x.email}</td>
                    <td>${x.first_name}</td>
                    <td>${x.last_name}</td>
                </tr>
                `;
                tableBody.appendChild(row);
            });

            console.log(usersResponse);
        })
}

function fetchRegresResources(pageNumber){

    const regres = "https://reqres.in"

    fetch(`${regres}/api/unknown/${pageNumber}`)
        .then(async response => {
            const bodyObject = await response.json();
            console.log(bodyObject);  
            
                const resourcesResponse = new ResourcesResponse(
                    bodyObject.data,
                    bodyObject.support
                );

                const tableBodyData = document.getElementById('box');

                const rowsToRemoveData = Array.from(tableBodyData.querySelectorAll('thead:not(:first-child)'));
                rowsToRemoveData.forEach(row => row.remove());

                    const rowData = document.createElement('thead');
                    rowData.innerHTML = `
                        <tr>
                            <td>${resourcesResponse.data.id}</td>
                            <td>${resourcesResponse.data.name}</td>
                            <td>${resourcesResponse.data.year}</td>
                            <td>${resourcesResponse.data.color}</td>
                            <td>${resourcesResponse.data.pantone_value}</td>
                        </tr>
                    `;
                    tableBodyData.appendChild(rowData);
                
                const tableBodySupport = document.getElementById('support');

                const rowsToRemoveSupport = Array.from(tableBodySupport.querySelectorAll('thead:not(:first-child)'));
                rowsToRemoveSupport.forEach(row => row.remove());

                    const rowSupport = document.createElement('thead');
                    rowSupport.innerHTML = `
                        <tr>
                            <td><a href="https://reqres.in/">${resourcesResponse.support.url}</a></td>
                            <td>${resourcesResponse.support.text}</td>
                        </tr>
                    `;
                    tableBodySupport.appendChild(rowSupport);
                    
                    
                console.log(resourcesResponse);
            
        })
}