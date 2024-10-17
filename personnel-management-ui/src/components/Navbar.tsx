
function Navbar() {
    return (
        <nav className="border-b-foreground border-b-2">
            <ul className="flex items-center justify-center container mx-auto">
                <li className=" justify-center items-center">
                <img src="/src/assets/react.svg" alt="site logo"/>
                </li>
                <li className="px-6 py-3 hover:text-link">
                    <a href="/" className="">Home</a>
                </li>
                <li className="px-6 py-3 hover:text-link">
                    <a href="/companies" className="">Companies</a>
                </li>
                <li className="px-6 py-3 hover:text-link">
                    <a href="/employees" className="">Employees</a>
                </li>
                <li className="px-6 py-3 hover:text-link">
                    <a href="/'+2sfd2d_" className="">Error page</a>
                </li>
                <li className="px-6 py-3 hover:text-link ml-auto">
                    <a href="/profile" className="">Profile</a>
                </li>
            </ul>

        </nav>
    );
}

export default Navbar;
