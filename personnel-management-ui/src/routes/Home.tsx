import Login from "@/components/Login.tsx";

export default function Home() {
  return (
    <main className="container mx-auto">
      <h1 className='text-4xl mt-[20%] mb-8 text-center'>
        Personnel Management
      </h1>
      <p className=''>
        {/*<a className='text-link hover:opacity-70' href="/src/components/Login">Login</a> if you are an user, or&nbsp;*/}
          <Login/>

      </p>
    </main>
  )
}
