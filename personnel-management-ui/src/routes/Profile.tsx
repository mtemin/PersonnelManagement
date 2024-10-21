
function Profile({user}) {
    return (
        <main>
            <div id="profile" className="text-center my-10">

            <p className="text-3xl">user name</p>
            <p className="text-2xl italic">user title</p>
                <p className="flex justify-center items-center mx-auto mt-10">
                    Working as <span>&nbsp;"ROLE"&nbsp;</span> in the company <span>&nbsp;"COMPANY"&nbsp;</span>
                </p>
            </div>
            <div className="flex justify-center">
                <div className="bg-zinc-950 border shadow rounded mx-10 px-4 py-2">
                    <p className="mx-4 text-lg font-bold">
                        Certificates
                    </p>
                    <ul>
                        <li className="my-4">
                            <p>Certificate Name</p>
                            <p>Issuing Organization</p>
                            <p>Total Hours</p>
                            <p>Description</p>
                            <p>Start Date - End Date</p>
                        </li>
                        <li className="my-4">
                            <span>-</span>
                            <p>Certificate Name</p>
                            <p>Issuing Organization</p>
                            <p>Total Hours</p>
                            <p>Description</p>
                            <p>Start Date - End Date</p>

                        </li>
                    </ul>
                </div>
                <div className="bg-zinc-950 border shadow rounded mx-10 px-4 py-2">
                    <p className="mx-4 text-lg font-bold">
                        Professional Experiences
                    </p>
                    <ul>
                        <li className="my-4">
                            <p>Company name</p>
                            <p>Job title</p>
                            <p>Description</p>
                            <p>Start Date - End Date</p>
                        </li>
                        <li className="my-4">
                            <span>-</span>
                            <p>Company name</p>
                            <p>Job title</p>
                            <p>Description</p>
                            <p>Start Date - End Date</p>
                        </li>
                    </ul>
                </div>
                <div className="bg-zinc-950 border shadow rounded mx-10 px-4 py-2">
                    <p className="mx-4 text-lg font-bold">
                        Educations
                    </p>
                    <ul>
                        <li className="my-4">
                        <p>Field Of Study</p>
                            <p>Description</p>
                            <p>Degree</p>
                            <p>Start Date - End Date</p>
                        </li>
                        <li className="my-4">
                            <span>-</span>
                            <p>Field Of Study</p>
                            <p>Description</p>
                            <p>Degree</p>
                            <p>Start Date - End Date</p>
                        </li>
                    </ul>
                </div>
            </div>
        </main>
    );
}

export default Profile;
